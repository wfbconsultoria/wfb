<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="_Footer_Scripts.ascx.vb" Inherits="Chapeira_Eplanner._Footer_Scripts" %>

<%--Bootstrap--%>
<script src="Scripts/jquery-3.0.0.min.js"></script>
<script>window.jQuery || document.write('<script src="Scripts/jquery-3.0.0.min.js"><\/script>')</script>
<script src="Scripts/popper.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<script src="Scripts/offCanvas.js"></script>

<%--PLugins Flacto--%>
<script src="Plugins/js/jquery.multi-select.js"></script>
<script src="Plugins/js/jquery.quicksearch.js"></script>

<%--PLugins Foo Table--%>
<script src="Plugins/js/demos.js"></script>
<script src="Plugins/js/footable.js"></script>
<script src="Plugins/js/footable.sort.js"></script>
<script src="Plugins/js/footable.filter.js"></script>
<script src="Plugins/js/footable.paginate.js"></script>

<!-- Responsive Table -->
<script type="text/javascript">
    $(function () {
        $('table').footable().bind('footable_filtering', function (e) {
            var selected = $('.filter-status').find(':selected').text();
            if (selected && selected.length > 0) {
                e.filter += (e.filter && e.filter.length > 0) ? ' ' + selected : selected;
                e.clear = !e.filter;
            }
        });

        $('.clear-filter').click(function (e) {
            e.preventDefault();
            $('.filter-status').val('');
            $('table.demo').trigger('footable_clear_filter');
        });

        $('.filter-status').change(function (e) {
            e.preventDefault();
            $('table.demo').trigger('footable_filter', { filter: $('#filter').val() });
        });

        $('.filter-api').click(function (e) {
            e.preventDefault();

            //get the footable filter object
            var footableFilter = $('table').data('footable-filter');

            alert('about to filter table by "tech"');
            //filter by 'tech'
            footableFilter.filter('tech');

            //clear the filter
            if (confirm('clear filter now?')) {
                footableFilter.clearFilter();
            }
        });

        $('#change-page-size').change(function (e) {
            e.preventDefault();
            var pageSize = $(this).val();
            $('.footable').data('page-size', pageSize);
            $('.footable').trigger('footable_initialized');
        });

        $('#change-nav-size').change(function (e) {
            e.preventDefault();
            var navSize = $(this).val();
            $('.footable').data('limit-navigation', navSize);
            $('.footable').trigger('footable_initialized');
        });

    });
</script>
